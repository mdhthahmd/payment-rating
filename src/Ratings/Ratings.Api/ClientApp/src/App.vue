<script setup>
import { Disclosure, DisclosureButton, DisclosurePanel, Menu, MenuButton, MenuItem, MenuItems } from '@headlessui/vue'
import { Bars3Icon, BellIcon, XMarkIcon } from '@heroicons/vue/24/outline'

const user = {
  name: 'Midhath Ahmed',
  email: 'mail@midhath.com',
  imageUrl: 'https://avatars.githubusercontent.com/u/52692343?v=4',
}
const navigation = [
  { name: 'Dashboard', to: '/' },
  { name: 'Employers', to: '/employers' },
  { name: 'Payments', to: '/payments' },
  { name: 'Pending', to: '/pending' },
]

const userNavigation = [
  { name: 'Your Profile', href: '#' },
  { name: 'Settings', href: '#' },
  { name: 'Sign out', href: '#' },
]
</script>

<template>
  <div class="min-h-full">
    <Disclosure as="nav" class="border-b border-gray-200 bg-white" v-slot="{ open, close }">
      <div class="mx-auto max-w-7xl px-4 sm:px-6 lg:px-8">
        <div class="flex h-16 justify-between">
          <div class="flex">
            <div class="flex flex-shrink-0 items-center">
              <img class="block h-8 w-auto lg:hidden" src="https://tailwindui.com/img/logos/mark.svg?color=red&shade=600" alt="Chiphko Inc" />
              <img class="hidden h-8 w-auto lg:block" src="https://tailwindui.com/img/logos/mark.svg?color=red&shade=600" alt="Chiphko Inc" />
            </div>
            <div class="hidden sm:-my-px sm:ml-6 sm:flex sm:space-x-8">
              <RouterLink
               v-for="item in navigation" :key="item.name" :to="item.to" 
               :class="[$route.path == item.to 
                  ? 'border-red-500 text-gray-900' : 'border-transparent text-gray-500 hover:border-gray-300 hover:text-gray-700', 'inline-flex items-center px-1 pt-1 border-b-2 text-sm font-medium']" 
                  :aria-current="$route.path == item.to ? 'page' : undefined">{{ item.name }}</RouterLink>
            </div>
          </div>
          <div class="hidden sm:ml-6 sm:flex sm:items-center">
            <a href="https://github.com/mdhthahmd/payment-rating" target="_blank"
              class="rounded-full bg-white p-1 text-gray-400 hover:text-gray-500 focus:outline-none focus:ring-2 focus:ring-red-500 focus:ring-offset-2">
              <span class="sr-only">Github repo link to this website</span>
              <svg class="h-6 w-6" aria-hidden="true" width="24" height="24" fill="none"
                xmlns="http://www.w3.org/2000/svg" id="svg726601300_739">
                <path fill-rule="evenodd" clip-rule="evenodd"
                  d="M11.987 2a9.977 9.977 0 0 0-3.15 19.447c.498.091.681-.217.681-.483v-1.662c-2.777.598-3.325-1.339-3.325-1.339A2.669 2.669 0 0 0 5.087 16.5c-.906-.616.066-.607.066-.607a2.12 2.12 0 0 1 1.53 1.03 2.129 2.129 0 0 0 2.902.832c.046-.507.27-.98.632-1.338-2.212-.25-4.548-1.106-4.548-4.93a3.85 3.85 0 0 1 1.03-2.678 3.558 3.558 0 0 1 .05-2.652s.832-.274 2.744 1.023a9.295 9.295 0 0 1 4.989 0c1.912-1.314 2.743-1.023 2.743-1.023.37.833.406 1.777.1 2.636a3.849 3.849 0 0 1 1.023 2.677c0 3.832-2.328 4.68-4.548 4.922a2.395 2.395 0 0 1 .682 1.837v2.735c0 .333.174.574.681.483A9.977 9.977 0 0 0 11.987 2Z"
                  fill="#808E9A"></path>
              </svg>
            </a>

            <!-- Profile dropdown -->
            <Menu as="div" class="relative ml-3">
                <MenuButton class="flex max-w-xs items-center rounded-full bg-white text-sm focus:outline-none focus:ring-2 focus:ring-red-500 focus:ring-offset-2">
                  <img class="h-8 w-8 rounded-full" :src="user.imageUrl" alt="" />
                </MenuButton>
            </Menu>
          </div>

          <div class="-mr-2 flex items-center sm:hidden">
            <!-- Mobile menu button -->
            <DisclosureButton class="inline-flex items-center justify-center rounded-md bg-white p-2 text-gray-400 hover:bg-gray-100 hover:text-gray-500 focus:outline-none focus:ring-2 focus:ring-red-500 focus:ring-offset-2">
              <span class="sr-only">Open main menu</span>
              <Bars3Icon v-if="!open" class="block h-6 w-6" aria-hidden="true" />
              <XMarkIcon v-else class="block h-6 w-6" aria-hidden="true" />
            </DisclosureButton>
          </div>
        </div>
      </div>

      <DisclosurePanel class="sm:hidden">
        <div class="space-y-1 pt-2 pb-3">
          <DisclosureButton @click="close" as="div">
            <RouterLink
              v-for="item in navigation" :key="item.name" :to="item.to"
              :class="[$route.path == item.to 
                ? 'bg-red-50 border-red-500 text-red-700' 
                : 'border-transparent text-gray-600 hover:bg-gray-50 hover:border-gray-300 hover:text-gray-800', 
                'block pl-3 pr-4 py-2 border-l-4 text-base font-medium']" 
                :aria-current="$route.path == item.to  ? 'page' : undefined"
            >{{ item.name }} </RouterLink>
          </DisclosureButton>
        </div>
        <div class="border-t border-gray-200 pt-4 pb-3">
          <div class="flex items-center px-4">
            <div class="flex-shrink-0">
              <img class="h-10 w-10 rounded-full" :src="user.imageUrl" alt="" />
            </div>
            <div class="ml-3">
              <div class="text-base font-medium text-gray-800">{{ user.name }}</div>
              <div class="text-sm font-medium text-gray-500">{{ user.email }}</div>
            </div>
            <a href="https://github.com/mdhthahmd/payment-rating" target="_blank"
            class="ml-auto flex-shrink-0 rounded-full bg-white p-1 text-gray-400 hover:text-gray-500 focus:outline-none focus:ring-2 focus:ring-red-500 focus:ring-offset-2">
            <span class="sr-only">Github repo link to this website</span>
              <svg class="h-6 w-6" aria-hidden="true" width="24" height="24" fill="none"
                xmlns="http://www.w3.org/2000/svg" id="svg726601300_739">
                <path fill-rule="evenodd" clip-rule="evenodd"
                  d="M11.987 2a9.977 9.977 0 0 0-3.15 19.447c.498.091.681-.217.681-.483v-1.662c-2.777.598-3.325-1.339-3.325-1.339A2.669 2.669 0 0 0 5.087 16.5c-.906-.616.066-.607.066-.607a2.12 2.12 0 0 1 1.53 1.03 2.129 2.129 0 0 0 2.902.832c.046-.507.27-.98.632-1.338-2.212-.25-4.548-1.106-4.548-4.93a3.85 3.85 0 0 1 1.03-2.678 3.558 3.558 0 0 1 .05-2.652s.832-.274 2.744 1.023a9.295 9.295 0 0 1 4.989 0c1.912-1.314 2.743-1.023 2.743-1.023.37.833.406 1.777.1 2.636a3.849 3.849 0 0 1 1.023 2.677c0 3.832-2.328 4.68-4.548 4.922a2.395 2.395 0 0 1 .682 1.837v2.735c0 .333.174.574.681.483A9.977 9.977 0 0 0 11.987 2Z"
                  fill="#808E9A"></path>
              </svg>
            </a>
          </div>
        </div>
      </DisclosurePanel>
    </Disclosure>


    <RouterView />

    <footer>
      <div class="mx-auto max-w-3xl px-4 sm:px-6 lg:max-w-7xl lg:px-8">
        <div class="border-t border-gray-200 py-8 text-center text-sm text-gray-500 sm:text-left">
          <span class="block sm:inline">&copy; {{new Date().getFullYear()}} Payment Rating, Inc.</span>
          <span class="block sm:inline">&nbsp;All rights reserved.</span>
        </div>
      </div>
    </footer>

  </div>
</template>

