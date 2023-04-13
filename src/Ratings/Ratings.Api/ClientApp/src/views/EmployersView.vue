<script setup>

const people = [
  { name: 'Lindsay Walton', title: 'Front-end Developer', email: 'lindsay.walton@example.com', role: 'Member' },
  // More people...
]




</script>

<template>




    <div class="py-10">
      <header>
        <div class="mx-auto max-w-3xl lg:max-w-7xl px-4 sm:px-6 lg:px-8">
          <h1 class="text-3xl font-bold leading-tight tracking-tight text-gray-900">Employers</h1>
        </div>
      </header>
      <main>
        <div class="mx-auto max-w-3xl lg:max-w-7xl sm:px-6 lg:px-8">
          
          <!-- Content -->
          <div class="px-4 py-8 sm:px-0">

    <div class="sm:flex sm:items-center">
      <div class="sm:flex-auto">
        <h1 class="text-base font-semibold leading-6 text-gray-900">Employers List</h1>
        <p class="mt-2 text-sm text-gray-700">A list of all the employers in the system.</p>
      </div>
      <div class="mt-4 sm:ml-16 sm:mt-0 sm:flex-none">
        <button type="button" class="block rounded-md bg-red-600 px-3 py-2 text-center text-sm font-semibold text-white shadow-sm hover:bg-red-500 focus-visible:outline focus-visible:outline-2 focus-visible:outline-offset-2 focus-visible:outline-red-600">Add user</button>
      </div>
    </div>
    <div class="mt-8 flow-root">
      <div class="-mx-4 -my-2 overflow-x-auto sm:-mx-6 lg:-mx-8">
        <div class="inline-block min-w-full py-2 align-middle sm:px-6 lg:px-8">
          <table class="min-w-full divide-y divide-gray-300">
            <thead>
              <tr>
                <th scope="col" class="py-3 pl-4 pr-3 text-left text-xs font-medium uppercase tracking-wide text-gray-500 sm:pl-0">Name</th>
                <th scope="col" class="px-3 py-3 text-left text-xs font-medium uppercase tracking-wide text-gray-500">Title</th>
                <th scope="col" class="px-3 py-3 text-left text-xs font-medium uppercase tracking-wide text-gray-500">Email</th>
                <th scope="col" class="px-3 py-3 text-left text-xs font-medium uppercase tracking-wide text-gray-500">Role</th>
                <th scope="col" class="relative py-3 pl-3 pr-4 sm:pr-0">
                  <span class="sr-only">Edit</span>
                </th>
              </tr>
            </thead>
            <tbody class="divide-y divide-gray-200 bg-white">
              <tr v-for="person in people" :key="person.email">
                <td class="whitespace-nowrap py-4 pl-4 pr-3 text-sm font-medium text-gray-900 sm:pl-0">{{ person.name }}</td>
                <td class="whitespace-nowrap px-3 py-4 text-sm text-gray-500">{{ person.title }}</td>
                <td class="whitespace-nowrap px-3 py-4 text-sm text-gray-500">{{ person.email }}</td>
                <td class="whitespace-nowrap px-3 py-4 text-sm text-gray-500">{{ person.role }}</td>
                <td class="relative whitespace-nowrap py-4 pl-3 pr-4 text-right text-sm font-medium sm:pr-0">
                  <a href="#" class="text-red-600 hover:text-red-900"
                    >Edit<span class="sr-only">, {{ person.name }}</span></a
                  >
                </td>
              </tr>
            </tbody>
          </table>
        </div>
      </div>
    </div>


    <nav class="flex items-center justify-between border-t border-gray-200 bg-white py-3" aria-label="Pagination">
    <div class="hidden sm:block">
      <p class="text-sm text-gray-700">
        Showing
        {{ ' ' }}
        <span class="font-medium">1</span>
        {{ ' ' }}
        to
        {{ ' ' }}
        <span class="font-medium">10</span>
        {{ ' ' }}
        of
        {{ ' ' }}
        <span class="font-medium">20</span>
        {{ ' ' }}
        results
      </p>
    </div>
    <div class="flex flex-1 justify-between sm:justify-end">
      <a href="#" class="relative inline-flex items-center rounded-md bg-white px-3 py-2 text-sm font-semibold text-gray-900 ring-1 ring-inset ring-gray-300 hover:bg-gray-50 focus-visible:outline-offset-0">Previous</a>
      <a href="#" class="relative ml-3 inline-flex items-center rounded-md bg-white px-3 py-2 text-sm font-semibold text-gray-900 ring-1 ring-inset ring-gray-300 hover:bg-gray-50 focus-visible:outline-offset-0">Next</a>
    </div>
  </nav>
          </div>
          <!-- /End Content -->
          
        </div>
      </main>
    </div>

  </template>